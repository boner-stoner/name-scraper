# name-scraper
made in 30 mins including the time i used to smash my head against the wall trying to fix bugs (i failed).  
fast but uses a LOT of ram (only if you're over 4 threads tho). writes all available names to usernames.txt.  
**estimated names per min is 900-1000**

## bugs
### the overwrite line bug
how it's supposed to look:   
![image](https://user-images.githubusercontent.com/85313522/130303171-e6bdd429-d30c-410c-a9df-1583fa3b8bd4.png)  
how it's NOT supposed to look:  
![image](https://user-images.githubusercontent.com/85313522/130303154-25a628a9-d083-4cbf-b882-9a4735ceed20.png)

**cause of this?**
just don't use more than 4 threads if u care about how it looks.
