# Lachesism

This is the middle sister dedicated To explain the protocol and document the evolution of the proyect.
## Starting protocol
-- 
### Funcions

SendOne  = 0x01  
SendMany = 0x02  
ReadOne  = 0x03  
ReadMany = 0x04  

### Format of numbers
Name          |  # of bytes  
---|---
Format8bit        |  1  
Format16bit       |  2  
Format32bit       |  4  

### protocol

Bytes protocol  
(works for all format of numbers 8-16-32)  


(# bytes)   |      Description  
---|---
1       |   Funcion  
1       |   Format
N       |   Number of data
N*F     |   Data stream