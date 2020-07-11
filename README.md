# Spotlight
It is a C# desktop application for windows for fast searching .The project builts a modified trie from the most used directories and indexes all possible prefixes from the prefix tree with an array of suggestions as autocomplete features , ranked/sorted by recently modified attribute .

## Usage
- Create a task in the task scheduler to run the ```python allfiles.py``` everyday to update the indexing of new files.
- Create a shortcut to the desktop of the Beta version present debug folder. 
- Assign to it your favourite key combination by going into the file properties.
- Type the key stroke assigned : Example Alt+Ctrl+Z


 ![Spotlight_demo](img/spotlight.gif)

## Requirements
- Windows


## Improvements Needed

- Need to even further optimize the code by doing in merging of N sorted list of size M.
- Think of using threads to update the UI.
- Add functionality to open the folder of the selected file .




