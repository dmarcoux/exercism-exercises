object Acronym {
    fun generate(phrase: String) : String {
        return phrase.split(" ", "-")
            .mapNotNull { it.find(Char::isLetter)?.uppercase() }
            .joinToString("")
    }
}
