# ElectricCarSalesTableAppRepo
 
The ElectricCarSalesTableApp application displays the result of sales in a tabular format.

The application takes cities, states, or countries as inputs for columns and months or years as input for rows in the form of a csv file. The first entry of every non-header row is the month or year, followed by sales values corresponding to the column headers.

The application requires a command-line argument pointing to the location of the csv file. The argument has the form --datapath=yourfilepath.
 
The application expects the first row to be headers for the columns, the first entry of the first row is ignored.
