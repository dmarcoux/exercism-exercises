object Acronym {
    fun generate(phrase: String) : String {
        return phrase.split(" ", "-")
            .mapNotNull { word -> word.dropWhile { !it.isLetter() }.firstOrNull()?.uppercase() }
            .joinToString("")
    }
}
