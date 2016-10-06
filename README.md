# w8hhf
W8HHF D-Star Scripts and Stuff

The following shows how to login to a remote machine with a key (not password) so you can automate the file copy command in the crontab listed for www.zackburns.com.  Some information has been obfuscated.


zburns@www:~/.ssh$ ssh-copy-id -p XXXXX -i id_rsa.pub "n8zak@w8hhf.dstargateway.org"
The authenticity of host '[w8hhf.dstargateway.org]:XXXXX ([aaa.bbb.ccc.ddd]:XXXXX)' can't be established.
RSA key fingerprint is ff:ff:ff:ff:ff:ff:ff:ff:ff:ff:ff:ff:ff:ff:ff:ff.
Are you sure you want to continue connecting (yes/no)? yes
/usr/bin/ssh-copy-id: INFO: attempting to log in with the new key(s), to filter out any that are already installed
/usr/bin/ssh-copy-id: INFO: 1 key(s) remain to be installed -- if you are prompted now it is to install the new keys
n8zak@w8hhf.dstargateway.org's password:

Number of key(s) added: 1

Now try logging into the machine, with:   "ssh -p 'XXXXX' 'n8zak@w8hhf.dstargateway.org'"
and check to make sure that only the key(s) you wanted were added.

zburns@www:~/.ssh$ ssh -p XXXXX n8zak@w8hhf.dstargateway.org
Last login: Thu Oct  6 09:59:28 2016 from aaa.bbb.ccc.ddd
[n8zak@W8HHF__G ~]$ exit
