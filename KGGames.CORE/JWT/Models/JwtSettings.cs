using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGGames.CORE.JWT.Models
{
    public class JwtSettings
    {
        public bool ValidateIssuerSigningKey { get; set; } //Veren imza anahtarini dogrula
        public string? IssuerSigningKey { get; set; } // Veren İmza Anahtarı
        public bool ValidateIssuer { get; set; } = true; //Duzenleyeni dogrula
        public string? ValidIssuer { get; set; } // Gecerli duzenleyen 
        public bool ValidateAudience { get; set; } = true; //Kitleyi dogrula
        public string? ValidAudience { get; set; } //Gecerli kitle
        public bool RequireExpirationTime { get; set; } //Sona erme suresi gerektirir
        public bool ValidateLifetime { get; set; } = true; //Kullanim omrunu dogrula
    }
}
