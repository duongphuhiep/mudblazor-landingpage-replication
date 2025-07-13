/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        "!./**/bin/",
        "!./**/obj/",
        "!./node_modules/",
        "./**/*.{razor,cshtml,css,html,js}",
    ],
    theme: {
        extend: {
            fontFamily: {
                sans: ["Public Sans", "Roboto", "Arial", "sans-serif"],
            },
        },
    },
    plugins: [],
};
