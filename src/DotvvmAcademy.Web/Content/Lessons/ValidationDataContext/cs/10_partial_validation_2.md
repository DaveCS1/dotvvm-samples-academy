��ste�n� validace II
====================
�pln� vypnout validaci m��ete p�id�n�m `Validation.Enabled="false"`. Toto nastaven� se takt� aplikuje na v�echny potomky elementu, 
na kter�m je tato vlastnost nastaven�.
        
V�im�te si, �e se validace spou�t� bindingem: `{command: nejakyPrikaz()}`.

Proto se vlastnost `Validation.Enabled` nebo `Validation.Target` mus� nastavovat na tla��tku nebo komponent�, kter� m� binding na p��kaz.
Vypnut� validace na jednotliv�ch textov�ch pol�ch formul��e nebude m�t ��dn� efekt.