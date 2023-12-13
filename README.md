# stock-data-visualizer
## Description
Program reads stock data from Excel files containing information on a given stock including: Ticker, Date, High, Low, Open, Close, Volume, Period. Users are able to select multiple excel files that are associated with a given period (week, month, year), and display the associated data on their own candlestick chart. Users can select start date and end date of data they would like to see. Users can view single candlestick and multi candlestick patterns that apply to the data displayed on the candlestick chart.

Technologies used:
- Windows Forms App .NET Framework
- C#
- Visual Studio 2022
- CsvHelper library: used to read excel data.

Programming Methodology:
- There are two main forms, one for displaying the initial selection of charts, and one for the individual candlestick charts.
- All patterns have their own file in the format of "PatternNameRecognizer.cs". All patterns inherit properties from "Recongnizer.cs".
- All functions and methods have comments describing their function/utility.

Challenges:
- Displayed data is currently not restricted to displaying only a set number of candlesticks per chart. If there is a large amount of candlesticks selected to display, the readability of the chart becomes difficult. Solutions are either to restrict the display of the candlesticks to some number or create a horizontal scroll wheel to scroll across the entirety of the selected candlesticks.
- Current implementation of showing which patterns are represented in the chart is unsatisfactory. Ideally, future implementation will involve a more dynamic approach, showing only a legend for selected patterns rather than showing all possible patterns the program can recognize.
- This implementation currently does not have any measures against bad user input/choices. Further testing and preventative measures should be implemented to avoid potential crashes/unwanted results.

## How to Install and Run
If you wish to run this implementation, you need to install the "Stock Data" folder and the folder labeled "Project2". These should be downloaded in the same repository. This implementation is run on Visual Studio 2022. The solution you should run is found in the folder "Project2", named "Project3.sln" (Discrepancies between file names is the result of an iterative process for the projects for the class this was developed for).

## How to Use
After running the "Project3.sln" solution, users should see the following:
![image](https://github.com/ATAshmore/stock-data-visualizer/assets/71903077/d2e15256-821b-4e67-a62c-b2913a35b95e)

Users can select the start date and end date of stocks they would like to see. The example stocks have dates up to October 2023. Users can select the "Load Stock" button to select which stocks they would like to view. They should see the following:
![image](https://github.com/ATAshmore/stock-data-visualizer/assets/71903077/67cb5b53-ecce-46b0-b71b-4528407bf9cf)

Users can select one file, multiple files, or no files. Users can also filter which stocks they see by selecting the period at the bottom right.
![image](https://github.com/ATAshmore/stock-data-visualizer/assets/71903077/b2c22517-4b93-4bc8-98dd-bdada0de7a62)
![image](https://github.com/ATAshmore/stock-data-visualizer/assets/71903077/cba07751-e987-41d2-bd5a-7da7002c41a6)

The selected stock should show up on its own form with a candlestick and volume chart:
![image](https://github.com/ATAshmore/stock-data-visualizer/assets/71903077/93fb0b09-fd79-4cac-af32-63b80eec86bb)

Users can change the start and end date and then select the "Update" button to update the dates:
![image](https://github.com/ATAshmore/stock-data-visualizer/assets/71903077/1571f41a-ff05-471a-aaaa-24d837f48ed4)

Users can select to see potential stock patterns that are on the current candlesticks by selecting the drop down for "Stock Pattern" then pressing "Update". Users can show multiple patterns by selecting each pattern and hitting update consecutively. Patterns can be cleared by hitting "Clear Patterns". The associated color for each pattern can be found in the legend at the bottom of the chart.
![image](https://github.com/ATAshmore/stock-data-visualizer/assets/71903077/3e17f7cc-a341-495e-be2b-ee66a3437e9c)




