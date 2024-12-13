## Commenting Convention

 * Voor de comments graag een beschrijving van wat iets als een functie of iets anders wat ingewikkeld kan zijn doet, zodat je team en jijzelf snel kan lezen wat iets doet.

 * Voor variabels is het alleen nodig als het wat ingewikkelder is, want als we voor alles comments gebruiken kan het onoverzichtelijk worden. 

 * Comments voor functions graag een line boven de function geschreven hebben, want dan is het duidelijk dat de comment bedoelt is voor de hele function.

 * Comments over iets specifieker in een function doe dan naast het betreffende line code, ook dit is wat overduidelijker en weet je gelijk over welke line het gaat.

 * Comments moeten leesbaar zijn en het liefst met genoeg informatie wat het doet, dit zorgt ervoor dat de comments overzichtelijker en begrijpelijk zijn.

# Voorbeelden goede comment: 
~~~
if (Input.GetMouseButtonDown(0))
{
    if (damageSystem != null)
    {
        damageSystem.GetDamage();
        this.enabled = false; // Deactivate the script after use
        OnMouseClickUsed?.Invoke(); // Notify that the script was used
    }
}
~~~

~~~
// Uses UnitDeath from IKill and makes sure that the objects gets destroyed and the value stays 0
public void UnitDeath() 
{
     Destroy(gameObject);  
    HealthPoints = 0; 
}
~~~

# Voorbeelden slechte comment:

~~~private HPSystem HealthText;  // References to the HPSystem component~~~

Dit is een slechte comment omdat het enigszins al duidelijk is wat dit line code doet. 
