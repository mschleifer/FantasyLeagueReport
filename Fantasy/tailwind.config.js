module.exports = {
    purge: [],
    darkMode: 'class', // false or 'media' or 'class'
    theme: {
        extend: {
            colors: {
                'fantasy-green': '#39B54A',
                'gray-font': '#494949',
                'darkest-gray': '#121212',
                'white-opacity-12': 'rgba(255,255,255,0.12)',
                'white-opacity-16': 'rgba(255,255,255,0.16)'
            }
        },
    },
    variants: {
        extend: {
            backgroundColor: ['odd','even'],
        }
    },
    plugins: [],
}
