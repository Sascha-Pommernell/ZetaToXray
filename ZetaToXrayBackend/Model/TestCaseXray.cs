using System;
namespace ZetaToXrayBackend.Model
{
    public class TestCaseXray
    {
        public int TCID {get; set;}
        public string? Zusammenfassung { get; set;}
        public string? Beschreibung { get; set;}
        public string? Komponente { get; set;}
        public string? MaxWiederholung { get; set;}
    }
}
