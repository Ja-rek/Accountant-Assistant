# Accountant Assistant

A part of an application created for the company ”Top Touristik,” which is rewriting by me from WPF to ElectronJs + ReactJs for educationalpurposes. 
The repository also describes my workflow and techniques that I like to use to perform my job.

## Requirements analysis
After a conversation with the client, a wrote some use cases. From the use cases, I made a requirement analysis.

ID: Summaries 001  
Name: Create a filled summaries sheet of travels.  
Description: As an accounting assistant I want to create a filled summaries sheet of travel from confirmations like invoices or booking confirms.

Acceptance criteria:  
Functional: 
  - Can I see an error notification when I try to process confirmations in an incorrect format?
  - Can I drag and drop confirmations to the application?
  - Can I load all confirmations to the application from a folder? 
  - Can I select confirmation files to load by clicks?
  - Can I delete or load more confirmations before creating summaries?
  - Can I Save Summaries of confirmations to the file in format xlsx?
  - Can I Save Summaries in two files one with Polish format, second in English format?

Not functional - system:  
  - Can run the application on Windows system?

Not functional - sved excel file:
  - Does the excel file contain a column named 'Kontrahent Pozycja Symfonia'?
  - Does the excel file contain a column named 'Data dokumentu'?
  - Does the excel file contain a column named 'Data wpływu' wich should be empty?
  - Does the excel file contain a column named 'Data operacji gospodarczej'?
  - Does the excel file contain a column named 'Document No.'?
  - Does the excel file contain a column named 'Description' wich should be empty?
  - Does the excel file contain a column named 'Original Amount'?
  - Does the excel file contain a column named 'Due Date' wich should be empty?
  - Does the excel file contain a column named 'Gen. Prod. Posting Group'?
  - Does the excel file contain a column named 'BookingNumber'?
  - Does the excel file contain a column named 'Passenger'?

-------------------------------------------------------------------------------------

ID: Confirmation template 001  
Name: Established template of Wizzair invoice.  
Description: Rewriting information from invoice to travel summary.

Acceptance criteria:  
Functional:
  - Can rewrite invoices in two language versions Pl and Eng?
  - Can rewrite prices in two formats like "165.80 PLN" or "165.80 EUR"?
  - Can prices contain minus?
  - Can rewrite the date, invoice number, booking number?

Not functional - properties:
  - Is the pdf file format supported?

-------------------------------------------------------------------------------------

ID: Confirmation template 002  
Name: Established template of Ryanair booking confirmation.  
Description: Rewriting information from booking confirmation to travel summar.   

Acceptance criteria:  
Functional:
  - Can rewrite confirmation in two language versions Pl and Eng?
  - Can rewrite prices in two formats like "165.80 PLN" or "165.80 EUR"?
  - Can rewrite passage names in the format like "PAN MARCIN KOWALSKI", "PAN MARCIN KOWALSKI-GOZDZIKOWY", "PAN MARCIN KOWALSKI GOZDZIKOWY"
  - Can prices contain minus?
  - Can rewrite the date, travel number?

Not functional - properties:
  - Is the eml file format supported?


## Architecture

In the future, it can be necessary to extend the accounting process by a new context. Let's say that it will be for example "Corporation Accountant context"'.

Let's look on the context map.

![](https://github.com/Ja-rek/Accountant-Assistant/blob/master/images/context-map.jpg?raw=true)

OK, now we see better.
So now let's look into the domain in the context of travel accountant.

![](https://github.com/Ja-rek/Accountant-Assistant/blob/master/images/travel-accountant.jpg?raw=true)

Yes, I know on first look it can be hard to understand. So let's look again straight to confirmation module.

![](https://github.com/Ja-rek/Accountant-Assistant/blob/master/images/confirmations.jpg?raw=true)

The summary module is associated with confirmation module. The confirmation module is moved outside only to make more clear summary module.

![](https://github.com/Ja-rek/Accountant-Assistant/blob/master/images/summary-service.jpg?raw=true)

Here I use a small trick with container inversion of controll to create a composit of summary service. 
Shortly the composit is selecting a concrete instance of summary service by a file extension.

![](https://github.com/Ja-rek/Accountant-Assistant/blob/master/images/summary-internal-modules.jpg?raw=true)

Here as you see I use dependency inversion to facilitate the extension with new modules.

![](https://github.com/Ja-rek/Accountant-Assistant/blob/master/images/money.jpg?raw=true)

I didn't use any compoment from nuget becouse I needed a custome factory with an extra parser.

A lot of things were skipped in the diagram it's just a general idea of this how the architecture should look like.

So just keep it in main.

## Testing

The tests have 4 sections unit, integration, functional and acceptance. Let me say some more about the way I testing.

### Unit tests

The naming convention of tests that I use is the same that is promoted by Roy Osherove.  
For example: ``UnitName_Scenario_Result``  

To make it easier to view the tests, I divided the class into parts according to the use case or the name of the unit.  
For example: ``RewriterServiceTest.CopyAmountFromConfirmation.cs``  

The convention of the namespace that is in tests is just copy the same path that has an unit.  
For example:  
Namespace of unit: ``Domain.Summaries``  
Namespace in unit tests: ``UnitTests.Domain.Summaries``

### Integration tests

The integration tests is using the same framework that unit tests. But in more complicated scenario I like to use LightBDD.

In one place I use generic tests usually I avoid this but in this case, it's completely fun.  
https://github.com/Ja-rek/Accountant-Assistant/tree/master/api/tests/TraveAccountant/IntegrationTests/Domain/Confirmations

### Functional tests

The functional tests are tests of Blackbox that will check that all functions of application work correctly. The stack that I use is Mocha and Chakram that supports BDD style.

### Acceptance tests

To acceptance tests I would like to use Spectron. Currently the client application is still in develop progres. This what you can see is just a prototype.
