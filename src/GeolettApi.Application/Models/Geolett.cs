using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeolettApi.Application.Models
{
    /// <summary>
    /// Geolett
    /// </summary>
    public class Geolett
    {
        /// <summary>
        /// kodeliste - åpen
        /// </summary>
        /// <example>Byggesak-treff-biomangfold-utvalgtnaturtype-hul eik</example>
        public string KontekstType { get; set; }
        /// <summary>
        /// Identifikasjonsnummer for tekstene
        /// </summary>
        /// <example>B67CD71F-397B-4096-BDEF-72D853600930</example>
        public string ID { get; set; }
        /// <summary>
        /// Overskrift
        /// </summary>
        /// <example>Hul eik</example>
        public string Tittel { get; set; }
        /// <summary>
        /// En begrunnelse for hvorfor søker gjøres oppmerksom på forholdet
        /// </summary>
        /// <example>Hul eik</example>
        public string ForklarendeTekst { get; set; }
        /// <summary>
        /// Lenker om det er ønskelig å lenke til mer utfyllende informasjon
        /// </summary>
        public List<Lenke> Lenker { get; set; }
        /// <example>Tiltaket er plassert nærmere enn 15m fra stammen til en hul eik som er utvalgt naturtype. Det kan påvirke den hule eika negativt.</example>
        public string Dialogtekst { get; set; }
        /// <summary>
        /// Denne teksten skal fungere som en hjelp til søkeren til å komme videre i prosessen
        /// </summary>
        /// <example>En arborist er en utdannet yrkesutøver innenfor trekonservering, trevedlikehold og planting. Arborister er kompetente når det gjelder trær og deres behov, og de er utdannet og utrustet for å gjennomføre de behandlingene som trengs. (Kilde: http://www.trefelling.nu/arborist/). Du kan finne arborister via Gule sider eller andre katalogtjenester.</example>
        public string MuligeTiltak { get; set; }
        /// <summary>
        /// Veiledende tekst om ett eller flere av de mulige tiltakene
        /// </summary>
        public string Veiledning { get; set; }
        public string Status { get; set; }
        public Datasett Datasett { get; set; }
        public Referanse Referanse { get; set; }
        /// <example></example>
        public string TekniskKommentar { get; set; }
        /// <example></example>
        public string AnnenKommentar { get; set; }
        /// <example></example>
        public string Tegn1 { get; set; }
        public string Tegn2 { get; set; }
        public string Tegn3 { get; set; }
        public string Tegn4 { get; set; }
        public string Tegn5 { get; set; }
        public string Tegn6 { get; set; }

    }

    public class Referanse
    {
        /// <example></example>
        public string Tittel { get; set; }
        /// <summary>
        /// Byggesaksforskrifter, lenke
        /// </summary>
        public Lenke Tek17 { get; set; }
        public Lenke AnnenLov { get; set; }
        public Lenke RundskrivFraDep { get; set; }
    }

    public class Datasett
    {
        /// <summary>
        /// Hvilket datasett tekstene er knyttet til
        /// </summary>
        /// <example>Naturtyper - utvalgte</example>
        public string Tittel { get; set; }
        /// <summary>
        /// Url til metadata om datasettet
        /// </summary>
        /// <example>https://kartkatalog.geonorge.no/metadata/2c0072de-f702-401e-bfb3-5ad3d08d4c2d</example>
        public string UrlMetadata { get; set; }
        /// <summary>
        /// Buffer avstand i meter
        /// </summary>
        /// <example>25</example>
        public int? BufferAvstand { get; set; }
        /// <summary>
        ///Generell tekst som sier at en må ta spesielle hensyn siden en er i nærheten av et område som krever særskilte hensyn
        /// </summary>
        /// <example>Eiketrær kan bli flere hundre år gamle og et stort mangfold av arter lever i hulrom, dype barkesprekker og på døde grener i slike trær. Så mange som 1500 arter kan leve på og i hule eiker. Hul eik er en utvalgt naturtype som skal tas hensyn til og vurderes i byggesøknaden</example>
        public string BufferText { get; set; }
        /// <summary>
        ///Tekst skal gi brukeren råd og veiledning om hva som bør gjøres eller ikke gjøres innenfor buffersonen til lokaliteten 
        /// </summary>
        public string BufferMuligeTiltak { get; set; }
        /// <summary>
        /// Url til gml-skjema
        /// </summary>
        /// <example>http://skjema.geonorge.no/SOSI/produktspesifikasjon/NaturtyperUtvalgte/20200320/NaturtyperUtvalgte.xsd</example>
        public string GmlSkjema { get; set; }
        /// <summary>
        /// Navnerom for datasett (target namespace)
        /// </summary>
        /// <example>http://skjema.geonorge.no/SOSI/Produktspesifikasjon/NaturtyperUtvalgte/20200320</example>
        public string Navnerom { get; set; }
        /// <summary>
        /// Objekttype, attributt og datasett skal sammen med type tiltak...
        /// </summary>
        public ObjektType TypeReferanse { get; set; }
    }
    public class ObjektType
    {
        /// <summary>
        /// Flomsone
        /// </summary>
        /// <example>BmNaturtype</example>
        public string Objekttype { get; set; }
        /// <summary>
        /// Sannsynlighet
        /// </summary>
        /// <example>bmUtvalgtNaturtype</example>
        public string Attributt { get; set; }
        /// <summary>
        /// 200
        /// </summary>
        /// <example>huleEiker</example>
        public string Kodeverdi { get; set; }

    }
    public class Lenke
    {
        /// <example>https://miljostatus.miljodirektoratet.no/tema/naturomrader-pa-land/skog/hule-eiker/</example>
        public string Href { get; set; }
        /// <example>Les mer om hul eik</example>
        public string Tittel { get; set; }
    }
}