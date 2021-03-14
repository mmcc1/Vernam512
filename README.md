# Vernam512 Cipher 1.0.3
A command line version of VernamHash Cipher

To encrypt:  
Vernam512 -e -i plaintext.txt -o ciphertext.512 -b 0  
To decrypt:  
Vernam512 -d -i ciphertext.512 -o plaintext.txt -b 0  
  
  
Parameters:  
-b                   - Byte selection (0-63)  
-d                   - Encrypt  
-e                   - Decrypt  
-h                   - Display help  
-i (filename)        - input file  
-o (filename)        - output file  
