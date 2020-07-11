#CODEMONK

##WHY : 

- Just before the placement season, while preparing I always had to go to either gfg, leetcode or techiedelight and then look for problems. And there would be a time that I had already solved that question or already done with the topic . So I came up with the idea of automating this process of mine to create some bot that would do the work for me. I previously had worked on an android application to web scrape for me the prices of products from amazon,flipkart and snapdeal but, this time since I wanted to code soutions to these problems , I wanted to make a plugin for a text editor.

- Now for me I had two choices for this. First , Visual Studio code or Sublime Text 3. I used both of them extensively , but for specific tasks. I used VScode primarily when I was working on a project, it had great collection of extensions , terminal, and great support for version control and git etc . But I used sublime text 3 mostly for small programs , especially during coding contests and eventually settled on choosing sublime text since its very light and fast.

##HOW : 

- I did some research on sublime text and its plugins and learnt that , its written in python . So I had started looking for appropriate libraries in python for web scraping . I settled on using Selenium and beautiful soup . I eventually thou8 of just making a python webscraping program which then later I could include into the python environment.

- For GFG the basic idea was to visit its must-to-coding-questions and select any random link from all those links. Then go to the selected random link and parse the Problem statement.

- For Leetcode it seemed easier at first because they already had a link which would redirect you to  a random question . For both the cases , I had to study their architecture a bit , of the page and view the html source in inspect element .


## Problems faced  : 
- For GFG , there were problems like identifying that the link chosen was in fact a coding question link and not anything else , this was solved by observing the prefix of coding questions of GFG included 'practice' . Also while extracting raw text I realised there were some improper spaces and new line character which was due to carraige return.

- Initially for leetcode, the code sometimes worked and sometimes it just did not which was confusing . It is after sometime I realised that leetcode used ajax and javascript to load its div and content , and normal webscraping methods only took care of static pages and not dynamic content loading , also leetcode often detected us as a bot . To overcome this , I used a headless Firefox , which basically would give an impression that it is a user returning to the site and not just a bot and then selenium's libraries helped in checking to parse the html only when the whole or a specific div/content had been loaded. Third problem , I faced was integrating this code into sublime text plugin environment. But all the external libraries that I used were not able to import into the plugin. Its after some research I go to know that sublime text used its own sandbox of python 3.3 which they had with them thier own libraries . After few days , I got a way around this by including the path for imp files / libraries in the very beginning of the plugin, so evertime the plugin is loaded , it will import those files for that plugin.





#Spotlight

##WHY : 

- I sometimes have bad experience with windows searching . It takes exteremely long time to set up first and sometimes , file searching takes too much of time and sometimes , files are not even found . Infact when the first time I saw Mac's searching mechanism - spotlight I was in awe of all its functionality , like it was super powerful , fast and extermely useful . Even with its keystrokes , cmd+space , the way it opened up in the middle of the screen kind of gave this sense of power on your hands to search anything on it , and ofcourse it was all due to it being super fluid !

- So before that I had downloaded , an app **** , which was similar to spotlight, had good-minimalistic feel to it . It was built in javascipt . But I soon had bugs using it , so gave up on it. It is then I deicided that I wanted to make a personal file searching app which should be atleast faster than my windows search and be as fluid as spotlight of mac. 

- I was in a dilemma to choose which framework and language to choose from for this app, I was divided between c++,c# and Js. C++ , because I was already familiar with it the best, but then found out that adding GUI to it wouldnt be as easy and flexible. I had almost decided to use electronJs for devloping the app but , I finally went with c# because its solely made for stuff like this - windows application and thought would provide a good set of options and flexibilty.

##HOW : 

I wanted in definition to create a trie first. A modified trie , who's each node would contain a character -> representing the end of curren string from root a string/file name/ prefix , which would have a list of all the files with the current string as its prefix in a sorted fashion by date added . So basically , the trie would contain all prefixes of file present on my laptop where corresponding to each prefix was the list of all files from that prefix to save time. Like we wouldnt need to do a dfs after every walk on the trie for the input string to get all the files with that prefix . 

To further improve the time complexity , I decided that it would be even better to index all these prefix to a corresponding list. So I ran a complete dfs on trie , after it is built to store for all prefix as key and all the files with that prefix as value in sorted fashion .



## Problems faced  :
- Had to think of a way to optimize just trie so came up with map
- The initial problem was to search for every file in the computer 
- C# took too much time on file handling
- Program crashed to access files with permission, ended using queues too
- Finally settled to use python for file indexing , as it was way faster and had more options 
- To have a limit for a particular input or else program was loading/blocked
- Also had an idea to save the state of the map for further use . But serializing - even tho more de-serializing took way too much time . Even the best of libraries for derserialising took more than 30 secs , which was too much time for startup.


# TypeGuess

##Why

- wanted to make fun experience on boring text based website
- didnt want to make complex game , but sometihing that can be done on the current context of the page.


##How
- Javascript only language for chrome plugins
- used API for meaning of words
- recursively removed half the words
- calculates Levenshtein / edit distance 


##Problems faced
- Searching for an easy to use , free API .
- Learning to communicate in chrome's environment. popup js to content js and so forth
- dissappering text and then making it reappear was not possible , so changed to reloading the page
