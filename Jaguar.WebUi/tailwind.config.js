/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./**/*.{razor,html}",
    "./**/(Layout|Pages)/*.{razor,html}",
    './**/*.{razor,html,cshtml}',
    './wwwroot/index.html'
  ],
  theme: {
    extend: {},
  },
  plugins: [],
}   