import * as React from 'react';
import { BarChart } from '@mui/x-charts/BarChart';

const valueFormatter = (value) => `${value}mm`;

const chartSetting = {
    yAxis: [
        {
            label: 'rainfall (mm)',
        },
    ],
    series: [{ dataKey: 'rainfall', label: 'Rainfall', valueFormatter }],
    height: 300,
};

const dataset = [
    { month: 'Jan', rainfall: 10 },
    { month: 'Feb', rainfall: 20 },
    { month: 'Mar', rainfall: 30 },
    { month: 'Apr', rainfall: 40 },
    { month: 'May', rainfall: 50 },
    { month: 'Jun', rainfall: 60 },
];

const BarChartAtom = () => {
    return (
        <div style={{ width: '100%' }}>
            <BarChart
                dataset={dataset}
                xAxis={[
                    {
                        scaleType: 'band',
                        dataKey: 'month',
                        tickPlacement: 'middle',
                        tickLabelPlacement: 'middle',
                    },
                ]}
                {...chartSetting}
            />
        </div>
    );
}


export default BarChartAtom