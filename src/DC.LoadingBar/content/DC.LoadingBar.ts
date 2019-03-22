namespace DC.LoadingBar {
    interface TimerHandle {
        handle: number | null;
    }

    class LoadingBar {

        

    }

    export function Load(): void {
        const loadingBar = {
            LoadingBar: new LoadingBar()
        };

        if (window['DC']) {
            window['DC'] = {
                ...window['DC'],
                ...loadingBar
            }
        }
        else {
            window['DC'] = {
                ...loadingBar
            }
        }
    }
}

DC.LoadingBar.Load();