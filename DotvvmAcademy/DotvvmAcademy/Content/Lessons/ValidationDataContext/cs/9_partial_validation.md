��ste�n� validace
=================
Implicitn� validaci spou�t� kter�koli tla��tko a to na cel�m viewmodelu
Pokud se n�kde ve viewmodelu vyskytne chyba, p��kaz se neprovede.

Nicm�n�, viewmodel �asto obsahuje objekty, kter� nechceme validovat v�bec.

V tomto p��pad� m��ete vyu��t `Validation.Target="{value: NejakaVlastnost}"`. 
Toto se d� aplikovat na kter�koli element �i komponentu v DotVVM.

Uvnit� tohoto elementu �i komponenty se validace provede pouze nad objektem, kter� byl dosazen do vlastnosti `Validation.Target`.