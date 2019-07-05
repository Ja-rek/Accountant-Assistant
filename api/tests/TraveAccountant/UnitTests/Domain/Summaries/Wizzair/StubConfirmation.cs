using System;
using TravelAccountant.Domain.Confirmations;

namespace TravelAccountant.UnitTests.Domain.Summaries.Wizzair
{
    public class StubConfirmation
    {
        public static ConfirmationPdf PLNVersion()
        {
            return ConfirmationPdfBuilder("PLN");
        }

        public static ConfirmationPdf EURVersion()
        {
            return ConfirmationPdfBuilder("EUR");
        }

        public static ConfirmationPdf IncorrectFormat()
        {
            var incorrectContent = $@" 
                STRONA | OLDAL 1 / 1

                052028953Z
                DATA TRANSAKsdfCJI | TELJESÍTÉS DÁTUMA
                2019.01.04
                Wizz Air Hungary Légiközlekedési Kft.
                ADRES | CÍM
                Budapest Kőér utca 2/A B épület II-V. em. 1103 HUN
                HU13122605

                2019.01.06
                TERMIN PŁATNOŚCI | FIZETÉSI HATÁRIDŐ
                2019.01.04
                ODBIORCA | VEVŐ NÉV
                TOP Touristik Sp. z o.o.
                ADRES | CÍM
                Poznań Piekary 6/13 0048616794 PL
                NIP ODBIORCY | VEVŐ ADÓSZÁM
                TOP Touristik Sp. z

                PNsdR | AZOsdfNOSÍTÓ
                N8P8MS

                WIZZ Air Hungary Kft.
                2019.01.06 16:52:02
                Signer:
                CN=WIZZ Air Hungary Kft. C=HU O=WIZZ Air Hungary Kft. E=WAHinvoices@wizzair.com

                RSA/2048 bits

                13122605-2-44

                ILOŚĆ MENNY.
                1,00

                JEDNOSTKA MIARY MÉRTÉKEGYSÉG
                Sztuk / db

                CENA JEDN. EGYSÉGÁR
                1272,00

                VAT% ÁFA%
                0.00 %

                KWOTA NETTO ÉRTÉKE ÁFA NÉLKÜL
                1272,00

                VAT ÁTHÁRÍTOTT ÁFA
                0,00

                KWOTA BRUTTO ÉRTÉKE ÁFÁVAL
                1272,00

                WALUTA PÉNZNEM
                PLN

                Bilet lotniczy / Repülőjegy (WAW-BCN / BCN-WAW)


                1272,00$


                0,00

                1272,00

                PLN

                PODSUMOWANIE VAT | ÁFA ÖSSZESÍTŐ

                VAT% ÁFA%

                KWOTA NETTO ÁFA ALAP

                KWOTA VAT ÁTHÁRÍTOTT ÁFA

                0.00 % 1272,00

                0,00

                TOTAL | ÖSSZESEN

                1272,00

                0,00

                KWOTA VAT HUF ÁTHÁRÍTOTT ÁFA HUF 0,00

                KWOTA BRUTTO SZÁMLA ÉRTÉK 1272,00
                1272,00

                WALUTA PÉNZNEM PLN
                PLN

                Zwolnione z VAT zgodnie z paragrafem 105 wegierskiej ustawy VAT Adómentes az Áfa tv. 105. § alapján
                A számla közvetített szolgáltatást tartalmaz.";

            return new ConfirmationPdf("Any.pdf", incorrectContent);
        }

        private static ConfirmationPdf ConfirmationPdfBuilder(string currency)
        {
            var content =$@"
                PAGE | OLDAL 1 / 1

                INVOICE NUMBER | SZÁMLASZÁM
                053683790Z
                DATE OF PERFORMANCE | TELJESÍTÉS DÁTUMA
                2019.02.04
                SUPPLIER NAME | SZÁLLÍTÓ NÉV
                Wizz Air Hungary Légiközlekedési Kft.

                INVOICE DATE | SZÁMLA KELTE
                2019.02.08
                DUE DATE | FIZETÉSI HATÁRIDŐ
                2019.02.04
                CUSTOMER NAME | VEVŐ NÉV
                TopTouristik TopTouristik

                PNR | AZONOSÍTÓ
                U576YR

                WIZZ Air Hungary Kft.
                2019.02.08 02:25:40
                Signer:
                CN=WIZZ Air Hungary Kft. C=HU O=WIZZ Air Hungary Kft. E=WAHinvoices@wizzair.com

                RSA/2048 bits

                ADDRESS | CÍM
                Budapest Kőér utca 2/A B épület II-V. em. 1103 HUN
                EU TAX NUMBER | UNIÓS ADÓSZÁM
                HU13122605

                ADDRESS | CÍM
                Poznan 6/13 Ul. Piekary 61-823 PL
                CUSTOMER TAX NUMBER | VEVŐ ADÓSZÁM

                TAX NUMBER | ADÓSZÁM
                13122605-2-44

                QTY MENNY.
                1,00

                UNIT OF MEASURE MÉRTÉKEGYSÉG
                pcs / db

                UNIT PRICE EGYSÉGÁR
                161,96

                VAT% ÁFA%
                0.00 %

                TYPE OF SERVICE | SZOLGÁLTATÁS
                Flight ticket / Repülőjegy (KTW-LCA / LCA-KTW)

                TOTAL EXCL. VAT ÉRTÉKE ÁFA NÉLKÜL
                161,96

                TOTAL VAT ÁTHÁRÍTOTT ÁFA
                0,00

                TOTAL INCL. VAT CURRENCY ÉRTÉKE ÁFÁVAL PÉNZNEM

                161,96

                {currency}

                TOTAL | ÖSSZESEN

                161,96

                161,96

                0,00

                161,96

                {currency}
                

                VAT SUMMARY | ÁFA ÖSSZESÍTŐ

                VAT% VAT BASE VAT AMOUNT

                VAT AMOUNT HUF

                ÁFA% ÁFA ALAP ÁTHÁRÍTOTT ÁFA ÁTHÁRÍTOTT ÁFA HUF

                0.00 % 161,96

                0,00

                0,00

                GRAND TOTAL SZÁMLA ÉRTÉK
                161,96

                CURRENCY PÉNZNEM
                {currency}

                TOTAL | ÖSSZESEN

                161,96

                0,00

                0,00

                161,96

                {currency}

                Exempt from VAT under sections 105 of the Hungarian VAT Act. Adómentes az Áfa tv. 105. § alapján
                A számla közvetített szolgáltatást tartalmaz.
                ";

            return new ConfirmationPdf("Any.pdf", content);
        }
    }
}
