# SplinterlandsCSVProcessor

Convert splinterlands trasaction output CSV to CoinTracker CSV format. 

***NOTE***
I am not a tax or financial expert and this was my guess at marking these transactions correctly, do not use this if you don't want to take a risk!!!
<br/>
<br/>

Cointracker Issues
* Importing DEC into Cointracker marks it as the wrong coin since there is another coin with the name DEC, you need to manually change it to Dark Energy Crystal DEC on Cointracker.


## Command Line Options

* v - verbose logs to console
* t - token type to parse, DEC, SPS or VOUCHER
* s - source file is required
* 0 - output file optional