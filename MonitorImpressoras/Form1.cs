using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonitorImpressoras
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // =========================================================
        // CARREGA AS IMPRESSORAS DO CSV
        // =========================================================
        private List<Impressoras> CarregarImpressoras()
        {
            List<Impressoras> impressoras = new List<Impressoras>();

            string caminho =
                @"C:\Users\matheus\Documents\Impressoras.csv";

            if (!File.Exists(caminho))
            {
                MessageBox.Show(
                    "Arquivo não encontrado:\n" + caminho,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return impressoras;
            }

            try
            {
                string[] linhas = File.ReadAllLines(caminho);

                // Começa em 1 porque a linha 0 é o cabeçalho
                for (int i = 1; i < linhas.Length; i++)
                {
                    if (string.IsNullOrWhiteSpace(linhas[i]))
                        continue;

                    // Detecta ; ou ,
                    char separador =
                        linhas[i].Contains(";") ? ';' : ',';

                    string[] dados =
                        linhas[i].Split(separador);

                    // Precisamos pelo menos:
                    // IP / Departamento / Modelo
                    if (dados.Length < 3)
                        continue;

                    string ip =
                        dados[0]
                        .Trim()
                        .Replace("\"", "");

                    IPAddress enderecoIp;

                    // Ignora x, vazio ou IP inválido
                    if (!IPAddress.TryParse(ip, out enderecoIp))
                        continue;

                    Impressoras impressora =
                        new Impressoras();

                    impressora.IP = ip;

                    impressora.Departamento =
                        dados[1]
                        .Trim()
                        .Replace("\"", "");

                    impressora.Modelo =
                        dados[2]
                        .Trim()
                        .Replace("\"", "");

                    impressoras.Add(impressora);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao ler a planilha:\n" +
                    ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            return impressoras;
        }

        // =========================================================
        // TESTA UMA ÚNICA IMPRESSORA
        // =========================================================
        private async Task<bool> VerificarImpressora(Impressoras impressora)
        {
            try
            {
                using (Ping ping = new Ping())
                {
                    PingReply resposta =
                        await ping.SendPingAsync(impressora.IP, 1500);

                    if (resposta.Status == IPStatus.Success)
                    {
                        SnmpImpressora snmp = new SnmpImpressora();

                        long? contador =
                            await snmp.ObterContador(impressora.IP);

                        string contadorTexto =
                            contador.HasValue
                            ? contador.Value.ToString("N0")
                            : "Não encontrado";

                        dgvImpressoras.Rows.Add(
                            impressora.IP,
                            impressora.Departamento,
                            impressora.Modelo,
                            "Online",
                            resposta.RoundtripTime + " ms",
                            contadorTexto,
                            DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
                        );

                        return true;
                    }

                    dgvImpressoras.Rows.Add(
                        impressora.IP,
                        impressora.Departamento,
                        impressora.Modelo,
                        "Offline",
                        "---",
                        "---",
                        DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
                    );

                    return false;
                }
            }
            catch
            {
                dgvImpressoras.Rows.Add(
                    impressora.IP,
                    impressora.Departamento,
                    impressora.Modelo,
                    "Erro",
                    "---",
                    "Não encontrado",
                    DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
                );

                return false;
            }

        }

        // =========================================================
        // BOTÃO VERIFICAR TODOS
        // =========================================================
        private async void btnVerificarTodos_Click(object sender,EventArgs e)
        {
            dgvImpressoras.Rows.Clear();

            List<Impressoras> impressoras =
                CarregarImpressoras();

            if (impressoras.Count == 0)
            {
                MessageBox.Show(
                    "Nenhuma impressora válida foi encontrada no CSV.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            btnVerificarTodos.Enabled = false;
            btnPesquisar.Enabled = false;

            int online = 0;
            int offline = 0;

            try
            {
                for (int i = 0;
                     i < impressoras.Count;
                     i++)
                {
                    Impressoras impressora =
                        impressoras[i];

                    lblStatus.Text =
                        "Verificando " +
                        (i + 1) +
                        " de " +
                        impressoras.Count +
                        " - " +
                        impressora.IP;

                    bool estaOnline =
                        await VerificarImpressora(
                            impressora
                        );

                    if (estaOnline)
                        online++;
                    else
                        offline++;
                }

                lblStatus.Text =
                    "Concluído - Total: " +
                    impressoras.Count +
                    " | Online: " +
                    online +
                    " | Offline: " +
                    offline;
            }
            finally
            {
                btnVerificarTodos.Enabled = true;
                btnPesquisar.Enabled = true;
            }
        }

        // =========================================================
        // BOTÃO PESQUISAR
        // =========================================================
        private async void btnPesquisar_Click(object sender, EventArgs e)
        {
            string pesquisa =
                txtPesquisar.Text.Trim();

            if (string.IsNullOrWhiteSpace(pesquisa))
            {
                MessageBox.Show(
                    "Digite o IP, departamento ou modelo da impressora.",
                    "Pesquisar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtPesquisar.Focus();

                return;
            }

            List<Impressoras> impressoras =
                CarregarImpressoras();

            if (impressoras.Count == 0)
            {
                MessageBox.Show(
                    "Nenhuma impressora foi carregada do CSV.",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            Impressoras encontrada =
                impressoras.Find(x =>
                    (x.IP ?? "").IndexOf(
                        pesquisa,
                        StringComparison.OrdinalIgnoreCase
                    ) >= 0
                    ||
                    (x.Departamento ?? "").IndexOf(
                        pesquisa,
                        StringComparison.OrdinalIgnoreCase
                    ) >= 0
                    ||
                    (x.Modelo ?? "").IndexOf(
                        pesquisa,
                        StringComparison.OrdinalIgnoreCase
                    ) >= 0
                );

            if (encontrada == null)
            {
                MessageBox.Show(
                    "Impressora não encontrada.\n\n" +
                    "Pesquisa: " +
                    pesquisa,
                    "Pesquisar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return;
            }

            dgvImpressoras.Rows.Clear();

            btnPesquisar.Enabled = false;
            btnVerificarTodos.Enabled = false;

            lblStatus.Text =
                "Verificando " +
                encontrada.IP +
                "...";

            try
            {
                bool estaOnline =
                    await VerificarImpressora(
                        encontrada
                    );

                if (estaOnline)
                {
                    lblStatus.Text =
                        encontrada.IP +
                        " está Online";
                }
                else
                {
                    lblStatus.Text =
                        encontrada.IP +
                        " está Offline";
                }
            }
            finally
            {
                btnPesquisar.Enabled = true;
                btnVerificarTodos.Enabled = true;
            }
        }

        // =========================================================
        // ENTER NA BARRA DE PESQUISA
        // =========================================================
        private void txtPesquisar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnPesquisar.PerformClick();

                e.SuppressKeyPress = true;
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            dgvImpressoras.Rows.Clear();

            txtPesquisar.Clear();

            lblStatus.Text = "Pronto";

            txtPesquisar.Focus();
        }

        private async void btnTesteSnmp_Click(object sender, EventArgs e)
        {
            string ip = txtPesquisar.Text.Trim();

            if (string.IsNullOrWhiteSpace(ip))
            {
                MessageBox.Show(
                    "Digite o IP da impressora.",
                    "SNMP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            IPAddress endereco;

            if (!IPAddress.TryParse(ip, out endereco))
            {
                MessageBox.Show(
                    "IP inválido: [" + ip + "]",
                    "SNMP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            SnmpImpressora snmp = new SnmpImpressora();

            long? contador =
                await snmp.ObterContador(ip);

            if (contador.HasValue)
            {
                MessageBox.Show(
                    "Contador da impressora: " +
                    contador.Value
                );
            }
            else
            {
                MessageBox.Show(
                    "A impressora respondeu ao IP, mas não foi possível obter o contador via SNMP."
                );
            }
        }
    }
}