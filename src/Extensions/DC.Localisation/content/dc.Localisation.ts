namespace DC.Localisation {
    class Localisation {
        public GetBrowserLocale(): string {
            return (navigator.languages && navigator.languages.length) ? navigator.languages[0] : navigator['userLanguage'] || navigator.language || navigator['browserLanguage'] || 'en';
        }
    }

    export function Load(): void {
        const localisation = {
            Localisation: new Localisation()
        };

        if (window['DC']) {
            window['DC'] = {
                ...window['DC'],
                ...localisation
            }
        }
        else {
            window['DC'] = {
                ...localisation
            }
        }
    }
}
DC.Localisation.Load();