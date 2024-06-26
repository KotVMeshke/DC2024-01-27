package by.haritonenko.jpa.util.entity;

import by.haritonenko.jpa.model.Author;
import by.haritonenko.jpa.util.TestBuilder;
import lombok.AllArgsConstructor;
import lombok.NoArgsConstructor;
import lombok.With;

@AllArgsConstructor
@NoArgsConstructor(staticName = "author")
@With
public class DetachedAuthorTestBuilder implements TestBuilder<Author> {

    private String login = "author2456";
    private String password = "asdfghj241";
    private String firstname = "firstname1294";
    private String lastname = "lastname6724";

    @Override
    public Author build() {
        Author author = new Author();

        author.setLogin(login);
        author.setFirstname(firstname);
        author.setPassword(password);
        author.setLastname(lastname);

        return author;
    }
}
