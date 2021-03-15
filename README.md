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
