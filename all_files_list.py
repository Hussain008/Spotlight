import os
import glob

all_files = []

def walking(path):
        global all_files

        #program fails if the size of the path is greater than 250 characters / cannot open it then
        files_in_cur_dir = [x for x in glob.glob(path) if len(x)<=250 ]

        for file in files_in_cur_dir : 

            #if current file is a directory , then recursively expand
            if(os.path.isdir(file)):
                walking(file+'\*')
            
            all_files.append(file)

            

def write_to_file():
    global all_files
    global count
    
    sorted_by_use =  sorted( all_files ,key=os.path.getctime)

    for file in sorted_by_use : 
        with open("C:\\Users\\gunny\\source\\repos\\Spotlight\\allFilesCopy.txt", "a", encoding="utf-8") as filewrite:
                    filewrite.write(file+"<"+str(count)+"\n")
                    count+=1

Apps = 'C:\ProgramData\Microsoft\Windows\Start Menu\Programs\*'
Documents = 'C:\\Users\\gunny\\Documents\\*'
Downloads = 'C:\\Users\\gunny\\Downloads\\*'
Desktop = 'C:\\Users\\gunny\\Desktop\\*'
count = 1

walking(Apps)
walking(Desktop)
walking(Documents)
walking(Downloads)

write_to_file()

