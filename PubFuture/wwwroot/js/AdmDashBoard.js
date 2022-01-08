function loadChart1(values, dates, update, darkTheme) {

    var sline = {
        chart: {
            height: 250,
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
        series: [values],
        grid: {
            row: {
                colors: ['#f1f2f3', 'transparent'], // takes an array which will be repeated on columns
                opacity: 0.5
            },
        },
        xaxis: {
            categories: dates,
        },
        yaxis: {
            labels: {
                formatter: function (value) {
                    var total = parseFloat(value);
                    var totalString = total.toLocaleString('pt-br', { minimumFractionDigits: 2 });

                    return "$ " + totalString;
                }
            },
        }
    }

    var chart = new ApexCharts(
        document.querySelector("#s-line"),
        sline
    );

    chart.render();

    if (update) {
        chart.updateOptions(sline);
    }
}


function loadChart2(values, dates, update) {

    var sCol = {
        chart: {
            height: 250,
            type: 'bar',
            toolbar: {
                show: false,
            }
        },
        plotOptions: {
            bar: {
                horizontal: false,
                columnWidth: '55%',
                endingShape: 'rounded'
            },
        },
        dataLabels: {
            enabled: false
        },
        stroke: {
            show: true,
            width: 2,
            colors: ['transparent']
        },
        series: [values],
        xaxis: {
            categories: dates,
        },
        yaxis: {
            labels: {
                formatter: function (value) {
                    var total = parseFloat(value);
                    var totalString = total.toLocaleString('pt-br', { minimumFractionDigits: 2 });

                    return totalString + " t";
                }
            },
        },
        fill: {
            opacity: 1
        }
    }

    var chart = new ApexCharts(
        document.querySelector("#s-col"),
        sCol
    );

    chart.render();

    if (update) {
        chart.updateOptions(sCol);
    }
}
