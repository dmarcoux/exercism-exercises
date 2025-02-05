object Acronym {
    fun generate(phrase: String) : String {
        return phrase.split(" ", "-")
            .filter(String::isNotEmpty)
            .fold("") { acronym, word -> acronym + word.dropWhile { !it.isLetter() }.first().uppercase() }
    }
}
