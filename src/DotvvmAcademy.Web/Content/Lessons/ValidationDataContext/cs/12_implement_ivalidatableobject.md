Implementace prost�ed� IValidatableObject
=========================================
Validaci vlastnost� `SubscriptionFrom` a `SubscriptionTo` budeme prov�d�t v k�du C#.
Mus�me napsat valida�n� pravidlo, kter� by zji��ovalo, kdy je `SubscriptionFrom` v�t�� ne� `SubscriptionTo`.

Za�neme t�m, �e `CustomerDetailViewModel` mus� implementovat prost�ed� `IValidatableObject`. Toto prost�ed� obsahuje metodu `Validate`, kter� mus� vracet seznam valida�n�ch chyb.
Jsou spojen� s chybami, kter� jsou vr�ceny valida�n�mi atributy, tak�e se nemus�te starat o dal�� vlastnosti.

Z t�to metody m��eme vr�tit novou valida�n� chybu pomoc� `yield return new ValidationResult("error message")`. 
Vra�te tuto chybu, pokud bude `SubscriptionFrom` v�t�� ne� `SubscriptionTo`.

[<CSharpExercise Initial="samples/CustomerDetailViewModel_Stage5.cs"
                 Final="samples/CustomerDetailViewModel_Stage6.cs"
                 DisplayName="CustomerDetailViewModel.cs"
                 ValidatorId="Lesson4Step12Validator">
</CSharpExercise>]