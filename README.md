# Vernam512 Cipher 1.0
A command line version of VernamHash Cipher

To encrypt:  
Vernam512 -e -k abc12345 -i plaintext.txt -o ciphertext.512 -b 0  
To decrypt:  
Vernam512 -d -k abc12345 -i ciphertext.512 -o plaintext.txt -b 0  
  
  
Parameters:  
-b                   - Byte selection (0-63)  
-d                   - Encrypt  
-e                   - Decrypt  
-h                   - Display help  
-i (filename)        - input file  
-k (key)             - Key - Must be 64 bytes or larger  
-o (filename)        - output file  
