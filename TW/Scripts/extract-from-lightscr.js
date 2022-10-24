const cheerio = require('cheerio')
const axios = require('axios')

/**
 * Extracts the jpg url from a LightShot page
 * lightshot_image('http://prntscr.com/dki21q')
 * http://image.prntscr.com/image/1aaf571d0adf4aa098eb565bbb196af6.png
 */

async function lightshotImageExtractor(url) {
    try {
        const { data } = await axios.get(url)
        const imgUrl = parseHTML(data)
        return imgUrl
    } catch (err) {
        console.log(err)
        return null
    }
}

function parseHTML(html) {
    const $ = cheerio.load(html)
    const rows = $('.screenshot-image')

    if (rows.length > 0 && rows[0].attribs && rows[0].attribs.src) {
        return rows[0].attribs.src
    }

    return null
}

lightshotImageExtractor('http://prntscr.com/dki21q').then((url) =>
    console.log(url),
)