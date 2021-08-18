mkdir $HOME/dotnet_install
cd $HOME/dotnet_install
wget https://packages.microsoft.com/config/ubuntu/21.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm -rf $HOME/dotnet_install

sudo apt-get update; sudo apt-get install -y apt-transport-https &&  sudo apt-get update &&  sudo apt-get install -y dotnet-sdk-3.1