namespace DC.Storage {
    class Storage {
        // 存储到本地持久化缓存
        public SetItem(type: string, key: string, data: string): void {
            if (type == "localStorage") {
                window.localStorage.setItem(key, data);
            }
            else {
                window.sessionStorage.setItem(key, data);
            }
        }

        // 从本地持久化缓存中读取数据
        public GetItem(type: string, key: string): string {
            if (type == "localStorage") {
                return window.localStorage.getItem(key);
            }
            else {
                return window.sessionStorage.getItem(key);
            }
        }

        // 删除数据项
        public RemoveItem(type: string, key: string): void {
            if (type == "localStorage") {
                window.localStorage.removeItem(key);
            }
            else {
                window.sessionStorage.removeItem(key);
            }
        }

        // 删除所有数据
        public Clear(type: string): void {
            if (type == "localStorage") {
                window.localStorage.clear();
            }
            else {
                window.sessionStorage.clear();
            }
        }

        // 获取本地持久化缓存中的数量
        public Length(type: string): number {
            if (type == "localStorage") {
                return window.localStorage.length;
            }
            else {
                return window.sessionStorage.length;
            }
        }

        // 获取本地持久化缓存中的指定序号的Key名
        public Key(type: string, index: number): string {
            if (type == "localStorage") {
                return window.localStorage.key(index);
            }
            else {
                return window.sessionStorage.key(index);
            }
        }
    }

    export function Load(): void {
        const storage = {
            Storage: new Storage()
        };

        if (window['DC']) {
            window['DC'] = {
                ...window['DC'],
                ...storage
            }
        }
        else {
            window['DC'] = {
                ...storage
            }
        }
    }
}

DC.Storage.Load();