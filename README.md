# Videnstjek - Quiz App

En moderne, interaktiv quiz-app bygget med Blazor WebAssembly til at hjælpe elever med at teste deres viden.

## 🎯 Formål

Videnstjek er designet til at give elever mulighed for at:
- Teste deres viden med kvalitetsfulde spørgsmål
- Få detaljerede forklaringer på alle svar
- Lære af deres fejl og forbedre sig
- Øve sig så meget de vil uden begrænsninger

**Vigtigt:** Appen gemmer ingen resultater eller svar - alt forbliver privat på brugerens enhed.

## 🚀 Funktioner

- **Moderne UI/UX**: Responsivt design der fungerer på alle enheder
- **Interaktive Quizzer**: Engagerende spørgsmål med multiple-choice svar
- **Detaljerede Forklaringer**: Læringsfokus med grundige forklaringer på alle svar
- **Progress Tracking**: Visuel fremgangsindikator gennem quizzen
- **Responsivt Design**: Fungerer perfekt på computer, tablet og mobil
- **Fremtrædende Resultater**: Quiz-afslutning vises som en centreret overlay med animerede elementer
- **Spørgsmål Oversigt**: Detaljeret oversigt over alle spørgsmål med farvekodning (grøn/rød) for korrekte/forkerte svar

## 🛠️ Teknologier

- **Frontend**: Blazor WebAssembly
- **Styling**: Bootstrap 5 + Custom CSS
- **Sprog**: C# + Razor
- **Ikoner**: Font Awesome
- **Framework**: .NET 9

## 📱 Nuværende Quiz

Appen indeholder en quiz om **JWT & Token Sikkerhed** med 4 spørgsmål:

1. **Access-token lagring** - Om hvor tokens gemmes på klienten
2. **Refresh tokens** - Formålet med refresh tokens
3. **Token fingerprinting** - Sikring af tokens til specifikke enheder
4. **Refresh token håndtering** - Hvordan man håndterer multiple enheder

## 🏃‍♂️ Kom i Gang

### Forudsætninger
- .NET 9 SDK
- En moderne webbrowser
- Docker Desktop (for container deployment)

### Installation
1. Klon repository'et
2. Naviger til `Blazor` mappen
3. Kør `dotnet restore`
4. Kør `dotnet run`
5. Åbn browseren på `https://localhost:5001`

### Bygning
```bash
dotnet build
dotnet run
```

### Docker Deployment
```bash
# Build og start med Docker Compose
docker-compose up --build

# Eller kør i baggrunden
docker-compose up -d --build

# Production deployment
docker-compose -f docker-compose.prod.yml up --build -d
```

Se `DOCKER.md` for detaljerede Docker instruktioner.

## 📁 Projektstruktur

```
videnstjek/
├── Blazor/                      # Blazor applikation
│   ├── Components/
│   │   ├── Layout/
│   │   │   ├── MainLayout.razor
│   │   │   └── NavMenu.razor
│   │   ├── Pages/
│   │   │   ├── Home.razor          # Forside
│   │   │   ├── QuizPage.razor      # Quiz funktionalitet
│   │   │   ├── QuizList.razor      # Quiz oversigt
│   │   │   ├── Admin.razor         # Quiz administration
│   │   │   └── About.razor         # Om siden
│   │   ├── App.razor               # Hovedapp
│   │   └── Routes.razor            # Routing
│   ├── wwwroot/
│   │   └── app.css                 # Custom styling
│   ├── Program.cs                  # App konfiguration
│   └── Dockerfile                  # Docker image definition
├── docker-compose.yml              # Development Docker Compose
├── docker-compose.prod.yml         # Production Docker Compose
├── deploy-docker.ps1               # PowerShell deployment script
├── deploy-docker.bat               # Windows batch deployment script
├── Makefile                        # Linux/macOS deployment
└── DOCKER.md                       # Docker deployment guide
```

## 🎨 Design Features

- **Gradient baggrunde** for moderne udseende
- **Floating animationer** på forsiden
- **Hover effekter** på interaktive elementer
- **Responsivt grid system** til alle skærmstørrelser
- **Konsistent farvepalet** med CSS variabler

## 🔒 Privatliv & Sikkerhed

- Ingen data gemmes på serveren
- Alle svar og resultater forbliver på brugerens enhed
- Ingen tracking eller analytics
- Fokus på læring og ikke på dataindsamling

## 🚧 Fremtidige Forbedringer

- Flere quiz kategorier
- Timer funktionalitet
- Læringsstatistik (lokalt)
- Offline support
- Quiz deling mellem elever

## 🔧 Admin Funktionalitet

Appen indeholder nu en admin-side på `/admin` hvor du kan:
- Se alle eksisterende quizzer i en overskuelig tabel
- Redigere eksisterende quizzer (titel, beskrivelse, spørgsmål, svar)
- Tilføje nye quizzer med multiple-choice spørgsmål
- Slette quizzer
- Administrere spørgsmål med forklaringer på alle svar

## 📝 Licens

Dette projekt er udviklet til undervisningsformål.

## 🤝 Bidrag

Velkommen til at bidrage med:
- Nye quiz spørgsmål
- UI/UX forbedringer
- Bug fixes
- Dokumentation

---

**Videnstjek** - Din personlige læringsassistent til at teste og forbedre din viden! 🧠✨
