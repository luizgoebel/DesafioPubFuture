function renderShippingPriceChart(data1, data2, data3) {
    var sLineArea = {
        chart: {
            height: 350,
            type: 'area',
            toolbar: {
                show: false,
            }
        },
        dataLabels: {
            enabled: false
        },
        stroke: {
            curve: 'smooth'
        },
        series: [data1, data2, data3],
        yaxis: {
            labels: {
                formatter: function (value) {
                    var total = parseFloat(value);
                    var totalString = total.toLocaleString('pt-br', { minimumFractionDigits: 2 });

                    return "$ " + totalString;
                }
            },
        },
        xaxis: { categories: ["Janeiro 1/2", "Janeiro 2/2", "Fevereiro 1/2", "Fevereiro 2/2", "Março 1/2", "Março 2/2", "Abril 1/2", "Abril 2/2", "Maio 1/2", "Maio 2/2", "Junho 1/2", "Junho 2/2", "Julho 1/2", "Julho 2/2", "Agosto 1/2", "Agosto 2/2", "Setembo 1/2", "Setembro 2/2", "Outubro 1/2", "Outubro 2/2", "Novembro 1/2", "Novembro 2/2", "Dezembro 1/2", "Dezembro 2/2"] },
    }

    var chart = new ApexCharts(
        document.querySelector("#hybrid_followers"),
        sLineArea
    );

    chart.render();

    chart.updateOptions(sLineArea);
}

function renderTotalOrdersChart(series, dark) {
    var stroke;
    if (dark) {
        stroke = {
            show: true,
            width: 25,
            colors: '#0e1726'
        };
    }
    else {
        stroke = {
            show: true,
            width: 25
        };
    }

    var options = {
        chart: {
            type: 'donut',
            width: 450
        },
        colors: ['#e2a03f', '#1abc9c', '#3b3f5c'],
        dataLabels: {
            enabled: false
        },
        legend: {
            position: 'bottom',
            horizontalAlign: 'center',
            fontSize: '14px',
            markers: {
                width: 10,
                height: 10,
            },
            itemMargin: {
                horizontal: 0,
                vertical: 8
            }
        },
        plotOptions: {
            pie: {
                donut: {
                    size: '65%',
                    background: 'transparent',
                    labels: {
                        show: true,
                        name: {
                            show: true,
                            fontSize: '29px',
                            fontFamily: 'Nunito, sans-serif',
                            color: undefined,
                            offsetY: -10
                        },
                        value: {
                            show: true,
                            fontSize: '26px',
                            fontFamily: 'Nunito, sans-serif',
                            color: '#263238',
                            offsetY: 16,
                            formatter: function (val) {
                                return parseFloat(val).toFixed(0)
                            }
                        },
                        total: {
                            show: true,
                            showAlways: true,
                            label: 'Pedidos',
                            color: '#263238',
                            formatter: function (w) {
                                return w.globals.seriesTotals.reduce(function (a, b) {
                                    return a + b
                                }, 0)
                            }
                        }
                    }
                }
            }
        },
        stroke: stroke,
        series: series,
        labels: ['Aguardando embarque', 'Em trânsito', 'Finalizados'],
        tooltip: {
            y: {
                format: 'dd/MM/yyyy',
            },
        },
        responsive: [{
            breakpoint: 1599,
            options: {
                chart: {
                    width: '100%',
                    height: '450px'
                },
                legend: {
                    position: 'bottom'
                }
            },
            breakpoint: 1439,
            options: {
                chart: {
                    width: '100%',
                    height: '450px'
                },
                legend: {
                    position: 'bottom'
                },
                plotOptions: {
                    pie: {
                        donut: {
                            size: '65%',
                        }
                    }
                }
            },
        }]
    }
    var chart = new ApexCharts(
        document.querySelector("#chart-2"),
        options
    );

    chart.render();
}

function renderOrdersValuesChart(orderData, months) {
    var d_1options1 = {
        chart: {
            height: 405,
            type: 'bar',
            toolbar: {
                show: false,
            }
        },
        colors: ['#1abc9c'],
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
        legend: {
            position: 'bottom',
            horizontalAlign: 'center',
            fontSize: '14px',
            markers: {
                width: 10,
                height: 10,
            },
            itemMargin: {
                horizontal: 0,
                vertical: 8
            }
        },
        grid: {
            borderColor: '#191e3a',
        },
        stroke: {
            show: true,
            width: 2,
            colors: ['transparent']
        },
        series: [{
            name: 'Valor Total de Pedidos',
            data: orderData,
        }],
        yaxis: {
            labels: {
                formatter: function (value) {
                    var total = parseFloat(value);
                    var totalString = total.toLocaleString('pt-br', { minimumFractionDigits: 2 });

                    return "$ " + totalString;
                }
            },
        },
        xaxis: {
            categories: months,
        },
        fill: {
            opacity: 1
        }
    }

    var d_1C_1 = new ApexCharts(document.querySelector("#chart-3"), d_1options1);
    d_1C_1.render();
    d_1C_1.updateOptions(d_1options1);

}

function changeOrdersValuesChart(btnElement, year) {
    var buttons = $('.btnChart3');
    var index = buttons.index(btnElement);

    buttons.each(function () {
        if (buttons.index($(this)) == index) {
            $(this).removeClass('btn-off');
            $(this).addClass('btn-active');
        }
        else {
            if (!$(this).hasClass('btn-off')) {
                $(this).addClass('btn-off');
            }

            $(this).removeClass('btn-active');
        }
    })

    $.ajax({
        url: '../CliDashBoard?handler=OrderValuesChartInfo',
        data: { year },
    }).done(function (result) {
        if (result.success) {
            renderOrdersValuesChart(result.values, result.months)
        }
    });
}

function renderOrdersTonsChart(orderData, months) {
    var d_1options2 = {
        chart: {
            height: 405,
            type: 'bar',
            toolbar: {
                show: false,
            }
        },
        colors: ['#406790'],
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
        legend: {
            position: 'bottom',
            horizontalAlign: 'center',
            fontSize: '14px',
            markers: {
                width: 10,
                height: 10,
            },
            itemMargin: {
                horizontal: 0,
                vertical: 8
            }
        },
        grid: {
            borderColor: '#406790',
        },
        stroke: {
            show: true,
            width: 2,
            colors: ['transparent']
        },
        series: [{
            name: 'Volume por toneladas',
            data: orderData,
        }],
        yaxis: {
            labels: {
                formatter: function (value) {
                    var total = parseFloat(value);
                    var totalString = total.toLocaleString('pt-br', { minimumFractionDigits: 2 });

                    return totalString + " t";
                }
            },
        },
        xaxis: {
            categories: months,
        },
        fill: {
            opacity: 1
        }
    }

    var d_1C_2 = new ApexCharts(document.querySelector("#chart-4"), d_1options2);
    d_1C_2.render();
    d_1C_2.updateOptions(d_1options2);
}

function changeOrdersTonsChart(btnElement, year) {
    var buttons = $('.btnChart4');
    var index = buttons.index(btnElement);

    buttons.each(function () {
        if (buttons.index($(this)) == index) {
            $(this).removeClass('btn-off');
            $(this).addClass('btn-active');
        }
        else {
            if (!$(this).hasClass('btn-off')) {
                $(this).addClass('btn-off');
            }

            $(this).removeClass('btn-active');
        }
    })

    $.ajax({
        url: '../CliDashBoard?handler=OrderTonsChartInfo',
        data: { year },
    }).done(function (result) {
        if (result.success) {
            renderOrdersTonsChart(result.values, result.months)
        }
    });
}