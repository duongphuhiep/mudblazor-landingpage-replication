/**
 * Highlight a list of country in the WorldMapImage.svg
 * @param {string[]} countryList
 * @param {string} className
 */
export function HighlightCountry(countryList, className = "fill-primary") {
    if (!countryList || !className) return;
    countryList.forEach(country => {
        const c = document.getElementById(country);
        c?.classList.add(className);
    })
}