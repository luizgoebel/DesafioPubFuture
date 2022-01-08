function chart1Config(series, labels) {
    var sline = {
        chart: {
            height: 350,
            type: 'line',
            zoom: {
                enabled: false
            },
            toolbar: {
                show: false,
            }
        },
        dataLabels: {
            enabled: false
        },
        stroke: {
            curve: 'straight'
        },
        series: [{
            name: "$",
            data: series
        }],
        grid: {
            row: {
                colors: ['#f1f2f3', 'transparent'], // takes an array which will be repeated on columns
                opacity: 0.5
            },
        },
        xaxis: {
            categories: labels,
        }
    }

    var chart = new ApexCharts(
        document.querySelector("#chartModalCustomerDashboard"),
        sline
    );

    chart.render();
    chart.update(sline);
}