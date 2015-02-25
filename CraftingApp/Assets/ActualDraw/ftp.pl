use strict;           
use Net::FTP;

my $host = "richer.tk";
my $user = "manu";
my $password = "=k1r0nn4g4";
my $file_to_put = "./sphere.prefab";

my $f = Net::FTP->new($host) or die "Can't open $host\n";
$f->login($user, $password) or die "Can't log $user in\n";
$f->put($file_to_put) or die "Can't put $file into $dir\n";