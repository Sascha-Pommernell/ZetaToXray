using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZetaToXrayFrontend.Model.Zeta
{
    public class TestCaseZeta
    {
        public string TestFallID { get; set; } = null!;
        public string TesteinheitTitel { get; set; } = null!;
        public string TesteinheitBeschreibung { get; set; } = null!;
        public string TestFallTitel { get; set; } = null!;
        public string Hierachie { get; set; } = null!;
        public string TestFallBeschreibung { get; set; } = null!;
        public string Variante { get; set; } = null!;
        public string TestfallDatum { get; set; } = null!;
        public string TestFallErstBenutzer { get; set; } = null!;
        public string TestFallAenderungsBenutzer { get; set; } = null!;
        public string ErwartetesErgebnis { get; set; } = null!;
        public string Vorbedingung { get; set; } = null!;
        public string Testschritte { get; set; } = null!;
        public string AnforderungsKapizelID { get; set; } = null!;
        public string ReviewBearbeitungsstatus { get; set; } = null!;
        public string ReviewGruppe { get; set; } = null!;
        public string TFSRequirementBugID { get; set; } = null!;
        public string Testpriorität { get; set; } = null!;
        public string TFSRequirementFeature { get; set; } = null!;
        public string Testdaten { get; set; } = null!;
        public string JiraTicket { get; set; } = null!;
    }
}
