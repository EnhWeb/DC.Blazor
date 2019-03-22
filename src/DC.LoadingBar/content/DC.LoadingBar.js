var __assign = (this && this.__assign) || function () {
    __assign = Object.assign || function(t) {
        for (var s, i = 1, n = arguments.length; i < n; i++) {
            s = arguments[i];
            for (var p in s) if (Object.prototype.hasOwnProperty.call(s, p))
                t[p] = s[p];
        }
        return t;
    };
    return __assign.apply(this, arguments);
};
var DC;
(function (DC) {
    var LoadingBar;
    (function (LoadingBar_1) {
        var LoadingBar = /** @class */ (function () {
            function LoadingBar() {
            }
            return LoadingBar;
        }());
        function Load() {
            var loadingBar = {
                LoadingBar: new LoadingBar()
            };
            if (window['DC']) {
                window['DC'] = __assign({}, window['DC'], loadingBar);
            }
            else {
                window['DC'] = __assign({}, loadingBar);
            }
        }
        LoadingBar_1.Load = Load;
    })(LoadingBar = DC.LoadingBar || (DC.LoadingBar = {}));
})(DC || (DC = {}));
DC.LoadingBar.Load();
//# sourceMappingURL=DC.LoadingBar.js.map