# Eksamensopgave i C#, efterår 2024
## Tid- og sagsregistreringssystem

![designklassediagram](https://github.com/user-attachments/assets/ce64cef8-86ab-4883-ae81-964fea6db3fa)

*Designklassediagram af min løsning*

## Opgavebeskrivelse
Der skal konstrueres en 3-lags arkitektur med en MVC App og en WPF App samt en database til et system til registrering af arbejdstid i en virksomhed.
Der er oplyst følgende om systemet:
- Der findes et antal afdelinger. En afdeling har et navn og et nummer.
- Det accepteres, at afdelinger hardcodes (minimum 3). Afdelinger kan implementeres som en DropDown liste.
- I virksomheden behandler de sager. En sag hører altid til een afdeling. Sagen har et sagsnr, en overskrift og en beskrivelse.
- Virksomheden har et antal medarbejdere. En medarbejder identificeres med en unikt initial og et cpr-nummer samt et navn.
- Der accepteres indskrænkninger til dette krav, f.eks. at en medarbejder kun er tilknyttet en afdeling eller at tilknytningen er hardcoded. Medarbejderen kan tilknyttes en afdeling fra en DropDown liste.
- Når en medarbejder har arbejdet på en sag, registrerer medarbejderen den brugte tid i systemet. Dette gøres ved at registrere det tidspunkt han startede på at arbejde på sagen og det tidspunkt han holdt op med at arbejde på sagen. Man kan sagtens arbejde på den samme sag ad flere omgange.
- Nogle gange laver medarbejderen arbejde, der ikke umiddelbart kan knyttes til en sag. I det tilfælde laver medarbejderen en tidsregistrering, men uden at sætte en sag på tidsregistreringen.

## Krav til besvarelsen
Der er følgende krav til besvarelsen. Applikationen skal laves med en tre lags arkitektur, der sikrer, at de centrale dele af applikationen kan bruges på tværs af forskellige grænseflader samt gøre brug af EntityFramework.
1. Et domæneklassediagram i UML (må gerne være tegnet i hånden).
2. Krav til MVC App:
- MVC App til registrering af arbejdstid for den enkelte medarbejder. Afdelinger må gerne være hard-coded i en DropDown liste.
- Der skal registreres 37 timer per uge for hver medarbejder.
- Der skal kunne vælges Sag til tidsregistrering fra en liste af sager (denne er oprettet fra WPF/MAUI App).
3. Krav til WPF App eller MAUI App:
- Oprette og vedligeholde data for medarbejdere og afdelinger (afdelinger må gerne være hardcoded). Dvs når en medarbejder oprettes kan der vælges en afdeling fra en hardcoded DropDown liste.
- Vise en oversigt over medarbejdere og deres timeregistrering.
- Timeregistrering skal kunne vises per uge og per måned og total.
- Appen tilgår business laget enten direkte eller via en udstilling af business laget som et Web API.
- Oprette og vedligeholde sager til tidsregistrering.
4. Der lægges stor vægt på at en bred del af alle fagområder benyttes i løsningen. Du skal som minimum benytte flg teknologier: Lambda udtryk og LINQ, HTML Helpers og Strongly Typed Models.
