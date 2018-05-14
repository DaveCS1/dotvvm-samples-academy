Pou�it� Validation.InvalidCssClass
==================================
Pomoc� vlastnosti `Validator.Value` jsme ozna�ili elementy, kter� se budou m�nit v z�vislosti 
na valida�n�ch nastaven�ch jednotliv�ch vlastnost�.
        
Te� mus�me specifikovat, co se m� st�t, kdy� vlastnost nebude validn�.
Dejme tomu, �e bychom cht�li p�idat CSS t��du `has-error` ka�d�mu tagu `div`, kdy� nebude validn�.
CSS t��da `has-error` zv�razn� textov� pole uvnit� tohoto tagu.

P�idejte vlastnost `Validator.InvalidCssClass="has-error"` ka�d�mu tagu `div`.

[<DothtmlExercise Initial="../samples/CustomerDetailView_Stage3.dothtml"
         Final="../samples/CustomerDetailView_Stage4.dothtml"
         DisplayName="CustomerDetailView.dothtml"
          ValidatorId="Lesson4Step4Validator" />]