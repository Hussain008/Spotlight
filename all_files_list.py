import os
import glob

def walking(path):
        global count

        #program fails if the size of the path is greater than 250 characters / cannot open it then
        files_in_cur_dir = [x for x in glob.glob(path) if len(x)<=250 ]

        #sort the files in the order of recently used 
        sorted_by_use =  sorted( files_in_cur_dir ,key=os.path.getctime)


        for file in sorted_by_use : 
            
            #if current file is a directory , then recursively expand
            if(os.path.isdir(file)):
                walking(file+'\*')

            with open("allFilesCopy.txt", "a", encoding="utf-8") as filewrite:
                filewrite.write(file+" "+str(count)+"\n")
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

