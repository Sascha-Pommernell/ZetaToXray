using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZetaToXrayBackend.Model
{
    internal class TestCaseZeta
    {
        public int TestFallID { get; set; }
        public string TesteinheitTitel { get; set; }
        public string TesteinheitBeschreibung { get; set; }
        public string TestFallTitel { get; set; }
        public string Hierachie { get; set; }
        public string TestFallBeschreibung { get; set; }
        public string Variante { get; set; }
        public DateTime TestfallDatum { get; set; }
        public string TestFallErstBenutzer { get; set; }
        public string TestFallAenderungsBenutzer { get; set; }
        public string ErwartetesErgebnis { get; set; }
        public string Vorbedingung { get; set; }
        public string Testschritte { get; set; }
        public int AnforderungsKapizelID { get; set; }
        public string ReviewBearbeitungsstatus { get; set; }
        public string RevierGruppe { get; set; }
        public int TFSRequirementBugID { get; set; }
        public string Testpriorität { get; set; }
        public string TFSRequirementFeature { get; set; }
        public string Testdaten { get; set; }
        public string JiraTicket { get; set; }
    }
}
