# Vernam512 Cipher 1.0.4
A command line version of VernamHash Cipher

To encrypt:  
Vernam512 -e [-k abc12345] -i plaintext.txt -o ciphertext.512 -b 0  
To decrypt:  
Vernam512 -d [-k abc12345] -i ciphertext.512 -o plaintext.txt -b 0  
[...] is an optional parameter.  
  
  
Parameters:  
-b                   - Byte selection (0-63)  
-d                   - Encrypt  
-e                   - Decrypt  
-h                   - Display help  
-i (filename)        - input file  
-k (Key)             - Optional. 64 byte min.  
-o (filename)        - output file  
  
Description  
    
Vernam512 is an implementation of the Vernam cipher without the requirement of One Time Pad (OTP) distribution.  The OTP is generated dymanically, from the key, using SHA512.  The minimum key length is 64 byts (512 bits).  
  
The security of the algorithm is directly related to the strength of SHA512 and proper key selection.  
  
Note on Byte Selection  
In generating the OTP from SHA512, there are 64 bytes returned as a hash.  The byte selection chooses one of these bytes to construct the OTP.  To successfully decrypt a file, two pieces of information must be provided.  The first is the Key and the second is the Byte Selection value.
