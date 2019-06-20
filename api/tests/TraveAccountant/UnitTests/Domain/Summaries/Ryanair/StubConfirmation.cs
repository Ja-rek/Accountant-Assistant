using System;
using TravelAccountant.Domain.Confirmations;

namespace TravelAccountant.UnitTests.Domain.Summaries.Ryanair
{
    public class StubConfirmation
    {
        public static ConfirmationEmail PLNVersion()
        {
            return ConfirmationEmailBuilder("PLN");
        }

        public static ConfirmationEmail EURVersion()
        {
            return ConfirmationEmailBuilder("EUR");
        }

        public static ConfirmationEmail IncorrectFormat()
        {
            var incorrectContent = "Paphos</div></td><tdalign=\"right\"valign=\"top\"style=\"color:#09237D;\"></div><div style=\"font-family:Arial"
                + ",Helvetica,sans-serif,\'Roboto';font-weight:bold;line-height:14px;white-space:nowrap;\">Ressdfsdfon:</div><divstyle=\"font-fami"
                + "ly:Arial,Helveticagn=\"right\"valign=\"top\"><strong>1645.27 PsdfLN</strong></td></tr></table><tableborder=\"0\"c";
            
            return new ConfirmationEmail("anyPath.eml", "Ryair Travel Itinerary", new DateTime(2019,01,25), incorrectContent);
        }

        private static ConfirmationEmail ConfirmationEmailBuilder(string currency)
        {
            var subject = "Ryanair Travel Itinerary";
            var date = new DateTime(2019,01,25);
            var content = "Paphos</div></td><tdalign=\"right\"valign=\"top\"style=\"color:#09237D;\">Reservation:</div><div style=\"font-family"
                + ":Arial,Helvetica,sans-serif,'Roboto';font-weight:bold;line-height:14px;white-space:nowrap;\">HTG93P</div></td></div><divstyle"
                + $"=\"font-family:Arial,Helveticagn=\"right\"valign=\"top\"><strong>1645.27 {currency}</strong></td></tr></table><tableborder=\"0\"c >"
                + "Mrs IZABELA MARCINKOWSKA KOWALSKA</td></tr>>Mr PIOTR KOWALSKI</td>>Mrs MAJA KOWALSKA-PETERSKA</td></tr>";

            return new ConfirmationEmail("anyPath.eml", subject, date, content);
        }
    }
}
