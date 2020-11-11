using System.Collections.Generic;

namespace NFO{
    public static class Dialogs {
        public static NpcDialogPart AkaraDialog = new NpcDialogPart(
            "Witaj, czy możesz mi pomóc dostać się do innego masta?",
            new List<HeroDialogPart>{
                new HeroDialogPart(
                    "Tak, chętnię pomogę",
                    new NpcDialogPart(
                        "Diękuję! W nagrodę otrzymasz ode mnie 100 sztuk złota",
                        new List<HeroDialogPart>{
                            new HeroDialogPart(
                                "Dam znać jak będę gotowy",
                                null
                                ),
                            new HeroDialogPart(
                                "100 sztuk złota to za mało!",
                                new NpcDialogPart(
                                    "Niestety nie mam więcej. Jestem bardzo biedny",
                                    new List<HeroDialogPart>{
                                        new HeroDialogPart(
                                            "OK, może być 100 sztuk złota",
                                            new NpcDialogPart(
                                                "Dziękuję",
                                                null
                                                )
                                            ),
                                        new HeroDialogPart(
                                            "W takim razie radź sobie sam",
                                            null
                                            )
                                        }
                                    )
                                )
                            }
                        )
                    ),
                new HeroDialogPart(
                    "Nie, nie pomogę, żegnaj.",
                    null
                    )
                }
            );

        public static NpcDialogPart CharsiDialog = new NpcDialogPart(
            "Witaj #HERONAME#, w czym mogę pomóc",
            new List<HeroDialogPart>{
                new HeroDialogPart(
                    "Dzień dobry, poszukuję łuku",
                        new NpcDialogPart(
                                "Aktualnie nie posiadamy na magazynie",
                                null
                            )
                    ),
                new HeroDialogPart(
                        "Dzień dobry, potrzebuję nowy miecz",
                        new NpcDialogPart(
                            "Proszę uprzejmie, mały 200 sztuk złota, średni 1000, duży 5000",
                            new List<HeroDialogPart> {
                                new HeroDialogPart(
                                    "Poproszę mały",
                                    null
                                    ),
                                new HeroDialogPart(
                                    "Poproszę średni",
                                    null
                                    ),
                                new HeroDialogPart(
                                    "Poproszę duży",
                                    null
                                    ),
                                new HeroDialogPart(
                                    "Dziękuję bardzo, ale są dla mnie zbyt drogie",
                                    null
                                    )
                            }
                        )
                    ),
                new HeroDialogPart(
                    "Proszę coś zaproponować",
                    new NpcDialogPart(
                        "Mamy bardzo dobrą kuszę za jedyne 2500 sztuk złota",
                        new List<HeroDialogPart> {
                            new HeroDialogPart(
                                "Tak, poproszę",
                                null
                                ),
                            new HeroDialogPart(
                                "Nie, dziękuję. Za droga jest dla mnie",
                                null
                                )
                            }
                        )
                    )
                }
            );
    }
}