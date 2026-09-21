using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Lextm.SharpSnmpLib;
using Lextm.SharpSnmpLib.Messaging;

namespace MonitorImpressoras
{
    public class SnmpImpressora
    {
        private const string Community = "public";

        public async Task<long?> ObterContador(string ip)
        {
            try
            {
                return await Task.Run(() =>
                {
                    IPAddress enderecoIp;

                    if (!IPAddress.TryParse(ip.Trim(), out enderecoIp))
                        return (long?)null;

                    IPEndPoint endpoint =
                        new IPEndPoint(enderecoIp, 161);

                    var resultado = Messenger.Get(
                        VersionCode.V2,
                        endpoint,
                        new OctetString(Community),
                        new List<Variable>
                        {
                    new Variable(
                        new ObjectIdentifier(
                            "1.3.6.1.2.1.43.10.2.1.4.1.1"
                        )
                    )
                        },
                        5000
                    );

                    if (resultado == null ||
                        resultado.Count == 0)
                    {
                        return (long?)null;
                    }

                    long valor;

                    if (long.TryParse(
                        resultado[0].Data.ToString(),
                        out valor))
                    {
                        return valor;
                    }

                    return (long?)null;
                });
            }
            catch
            {
                return null;
            }
        }
    }
}