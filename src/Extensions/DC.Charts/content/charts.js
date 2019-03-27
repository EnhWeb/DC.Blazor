window.DC.BueCharts = {
    setChartData: (canvasId, type, data, options, dataIsString, optionsIsString) => {
        if (dataIsString)
            data = JSON.parse(data);

        if (optionsIsString)
            options = JSON.parse(options);

        //console.log(type);
        //console.log(JSON.stringify(data));
        //console.log(JSON.stringify(options));

        const chart = DC.BueCharts.getChart(canvasId);

        if (chart) {
            chart.config.data = data;
            chart.config.options = options;
            chart.update();
        } else {
            const canvas = document.getElementById(canvasId);

            if (canvas) {
                new Chart(canvas, {
                    type: type,
                    data: data,
                    options: options
                });
            }
        }

        return true;
    },

    getChart: (canvasId) => {
        let chart = null;

        Chart.helpers.each(Chart.instances, function (instance) {
            if (instance.chart.canvas.id === canvasId) {
                chart = instance.chart;
            }
        });

        return chart;
    }
};