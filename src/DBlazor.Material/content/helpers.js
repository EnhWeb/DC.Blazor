if (!window.DBlazorMaterial) {
    window.DBlazorMaterial = {};
}

window.DBlazorMaterial = {
    activateDatePicker: (elementId, formatSubmit) => {
        const element = $(`#${elementId}`);

        element.pickdate({
            ok: '',
            cancel: 'Clear',
            today: 'Today',
            closeOnCancel: true,
            closeOnSelect: true,
            container: 'body',
            containerHidden: 'body',
            firstDay: 1, // monday
            format: 'dd.mm.yyyy',
            formatSubmit: formatSubmit,
            onClose: function (s) {
                // trigger onchange event on the DateEdit component
                mutateDOMChange(elementId);
            }
        });
        return true;
    }
};

function mutateDOMChange(id) {
    el = document.getElementById(id);
    ev = document.createEvent('Event');
    ev.initEvent('change', true, false);
    el.dispatchEvent(ev);
}