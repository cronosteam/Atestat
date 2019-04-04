O sa-ti trebuiasca xampp pentru baza de date, nodejs pentru server, si de instalat pachete ca sa mearga serverul
ca sa instalezi pachetele pentru server, pur si simplu:
dupa ce ai instalat node, deschizi o consola in folderul cu proiectul, si dai comanda
npm install mysql express

Cam atat pentru pachete
Dupa, deschizi proiectul Chronos.sln cu Visual Studio
dai click dreapta pe el, in panoul din dreapta, si dai click pe "Manage NuGet Packages"
Dai browse, cauti System.net.http si o instalezi, updatezi, etc
Mai cauti si Newsofton.Json si o instalezi si pe aia
dupa, ar trebui sa mearga
Totusi, o sa-ti trebuiasca si o baza de date pe care sa o acceseze serverul.
Pentru asta, in phpMyAdmin bagi textul din chronos.sql, sau dai import la fisier.