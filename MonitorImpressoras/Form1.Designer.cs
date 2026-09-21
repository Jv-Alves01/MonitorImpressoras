namespace MonitorImpressoras
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btnVerificarTodos = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtPesquisar = new System.Windows.Forms.TextBox();
            this.dgvImpressoras = new System.Windows.Forms.DataGridView();
            this.btnTesteSnmp = new System.Windows.Forms.Button();
            this.colIp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepartamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUltimaVerificacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImpressoras)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(61, 369);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpar.TabIndex = 0;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(462, 36);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(75, 23);
            this.btnPesquisar.TabIndex = 1;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // btnVerificarTodos
            // 
            this.btnVerificarTodos.Location = new System.Drawing.Point(592, 36);
            this.btnVerificarTodos.Name = "btnVerificarTodos";
            this.btnVerificarTodos.Size = new System.Drawing.Size(164, 23);
            this.btnVerificarTodos.TabIndex = 2;
            this.btnVerificarTodos.Text = "Verificar todos";
            this.btnVerificarTodos.UseVisualStyleBackColor = true;
            this.btnVerificarTodos.Click += new System.EventHandler(this.btnVerificarTodos_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(513, 374);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(65, 13);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Aguardando";
            // 
            // txtPesquisar
            // 
            this.txtPesquisar.Location = new System.Drawing.Point(61, 38);
            this.txtPesquisar.Name = "txtPesquisar";
            this.txtPesquisar.Size = new System.Drawing.Size(395, 20);
            this.txtPesquisar.TabIndex = 4;
            this.txtPesquisar.Text = "pesquisar";
            // 
            // dgvImpressoras
            // 
            this.dgvImpressoras.AllowUserToAddRows = false;
            this.dgvImpressoras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvImpressoras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvImpressoras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIp,
            this.colDepartamento,
            this.colModelo,
            this.colStatus,
            this.colPing,
            this.colContador,
            this.colUltimaVerificacao});
            this.dgvImpressoras.Location = new System.Drawing.Point(61, 77);
            this.dgvImpressoras.Name = "dgvImpressoras";
            this.dgvImpressoras.ReadOnly = true;
            this.dgvImpressoras.RowHeadersVisible = false;
            this.dgvImpressoras.RowHeadersWidth = 51;
            this.dgvImpressoras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvImpressoras.Size = new System.Drawing.Size(695, 286);
            this.dgvImpressoras.TabIndex = 5;
            // 
            // btnTesteSnmp
            // 
            this.btnTesteSnmp.Location = new System.Drawing.Point(157, 369);
            this.btnTesteSnmp.Name = "btnTesteSnmp";
            this.btnTesteSnmp.Size = new System.Drawing.Size(75, 23);
            this.btnTesteSnmp.TabIndex = 6;
            this.btnTesteSnmp.Text = "Teste";
            this.btnTesteSnmp.UseVisualStyleBackColor = true;
            this.btnTesteSnmp.Click += new System.EventHandler(this.btnTesteSnmp_Click);
            // 
            // colIp
            // 
            this.colIp.HeaderText = "Ip";
            this.colIp.MinimumWidth = 6;
            this.colIp.Name = "colIp";
            this.colIp.ReadOnly = true;
            // 
            // colDepartamento
            // 
            this.colDepartamento.HeaderText = "Departamento";
            this.colDepartamento.MinimumWidth = 6;
            this.colDepartamento.Name = "colDepartamento";
            this.colDepartamento.ReadOnly = true;
            // 
            // colModelo
            // 
            this.colModelo.HeaderText = "Modelo";
            this.colModelo.MinimumWidth = 6;
            this.colModelo.Name = "colModelo";
            this.colModelo.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Status";
            this.colStatus.MinimumWidth = 6;
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // colPing
            // 
            this.colPing.HeaderText = "Ping";
            this.colPing.MinimumWidth = 6;
            this.colPing.Name = "colPing";
            this.colPing.ReadOnly = true;
            // 
            // colContador
            // 
            this.colContador.HeaderText = "Contador";
            this.colContador.Name = "colContador";
            this.colContador.ReadOnly = true;
            // 
            // colUltimaVerificacao
            // 
            this.colUltimaVerificacao.HeaderText = "Última Verificação";
            this.colUltimaVerificacao.MinimumWidth = 6;
            this.colUltimaVerificacao.Name = "colUltimaVerificacao";
            this.colUltimaVerificacao.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 418);
            this.Controls.Add(this.btnTesteSnmp);
            this.Controls.Add(this.dgvImpressoras);
            this.Controls.Add(this.txtPesquisar);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnVerificarTodos);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.btnLimpar);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvImpressoras)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Button btnVerificarTodos;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtPesquisar;
        private System.Windows.Forms.DataGridView dgvImpressoras;
        private System.Windows.Forms.Button btnTesteSnmp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepartamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPing;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContador;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUltimaVerificacao;
    }
}

