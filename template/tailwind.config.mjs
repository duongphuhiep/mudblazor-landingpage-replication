import plugin from "tailwindcss/plugin";

/** @type {import('tailwindcss').Config} */
export default {
    plugins: [
        plugin(function ({ matchUtilities, theme }) {
            matchUtilities(
                {
                    mks: (value) => ({
                        "margin-block-start": value,
                    }),
                    mke: (value) => ({
                        "margin-block-end": value,
                    }),
                    pks: (value) => ({
                        "padding-block-start": value,
                    }),
                    pke: (value) => ({
                        "padding-block-end": value,
                    }),
                },
                { values: theme("spacing") }
            );
        }),
    ],
};
