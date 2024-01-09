# Requirements

1. Visual Studio Code 2022
2. DotNet Framework 4.8.x - runtime + SDK

# ATENTIE!
Rularea proiectului pe mai mult de un monitor provoaca niste probleme
(cubul nu apare) #TODO - fix cube render on multiple monitors.

# Laborator 2
1. Modificarea Viewportului defineste suprafata pe care proiectia scenei 3D va avea loc.
>
3. 
- Un Viewport permite utilizatorului sa simuleze o camera pentru a viziona obiectele create din diferite unghiuri.
- Conceptul de frames per second reprezinta numarul de cadre afisate intr-o secunda de program.
- Metoda OnUpdateFrame() este rulata odata dupa initializare OnLoad(), apoi repetata urmarind numarul de cadre pe secunda specificat.
- In modul imediat de randare, aplicația trimite comenzi grafice direct catre GPU pentru fiecare obiect sau detaliu individual care trebuie desenat pe ecran.
- Incepand cu versiunea OpenGL 3.0 Modul imediat nu mai este suportat, prin urmare o versiune recomandata este OpenGL 2.1.
- OnRenderFrame() este rulata dupa fiecare OnUpdateFrame sau repetat urmarind numarul de cadre pe secunda.
- OnResize() trebuie rulata cel putin odata pentru a adapta fereastra noastra la dimensiunea ecranului.
- Parametri metodei CreatePerspectiveFieldOfView() sunt:
a) fieldOfView - campul de vedere intre 0 si 180 grade
b) aspectRatio - raportul dintre latimea si lungimea ferestrei, poate lua orice valoare reala.
c) nearPlane - distanta de la camera pana la sectiunea de randat.
d) farPlane - distanta pana la capatul volumului de randat.
