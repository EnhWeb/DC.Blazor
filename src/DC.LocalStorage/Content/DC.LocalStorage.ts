namespace DC.LocalStorage {
    class LocalStorage {
        // 存储到本地持久化缓存
        public SetItem(key: string, data: string): void {
            window.localStorage.setItem(key, data);
        }

        // 从本地持久化缓存中读取数据
        public GetItem(key: string): string {
            return window.localStorage.getItem(key);
        }

        // 删除数据项
        public RemoveItem(key: string): void {
            window.localStorage.removeItem(key);
        }

        // 删除所有数据
        public Clear(): void {
            window.localStorage.clear();
        }

        // 获取本地持久化缓存中的数量
        public Length(): number {
            return window.localStorage.length;
        }

        // 获取本地持久化缓存中的指定序号的Key名
        public Key(index: number): string {
            return window.localStorage.key(index);
        }
    }

    export function Load(): void {
        const localStorage = {
            LocalStorage: new LocalStorage()
        };

        if (window['DC']) {
            window['DC'] = {
                ...window['DC'],
                ...localStorage
            }
        }
        else {
            window['DC'] = {
                ...localStorage
            }
        }
    }
}

DC.LocalStorage.Load();